//-----------------------------------------------------------------------
// <copyright file="ProcessBase.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.workflow
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public class ProcessBase<TState, TStep>
        where TStep : ProcessStepBase
        where TState : new()
    {
        private Action<ProcessBase<TState, TStep>> done;
        private int position = -1;
        private Frame rootFrame = Window.Current.Content as Frame;
        private List<TStep> steps = new List<TStep>();
        private int totalSteps = 0;

        public ProcessBase(Action<ProcessBase<TState, TStep>> done, IEnumerable<TStep> steps)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }

            this.ProcessState = new TState();
            this.done = done;
            this.steps = new List<TStep>(steps);
            UpdateSteps();
            rootFrame.Navigated += rootFrame_Navigated;
            rootFrame.Navigating += rootFrame_Navigating;
        }

        public TStep CurrentStep
        {
            get
            {
                try
                {
                    if (position == -1 || position >= steps.Count)
                    {
                        return null;
                    }

                    return steps[position];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
                catch (IndexOutOfRangeException)
                {
                    return null;
                }
            }
        }

        public int CurrentStepIndex
        {
            get
            {
                return position;
            }
        }

        public TStep NextStep
        {
            get
            {
                try
                {
                    return steps[CurrentStepIndex + 1];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
                catch (IndexOutOfRangeException)
                {
                    return null;
                }
            }
        }

        public TState ProcessState { get; private set; }

        public ReadOnlyCollection<TStep> Steps { get; private set; }

        public int TotalSteps
        {
            get
            {
                return totalSteps;
            }
        }

        public void InsertNextStep(TStep newStep)
        {
            steps.Insert(position + 1, newStep);
            UpdateSteps();
        }

        public void Next()
        {
            if (steps.Count == 0)
            {
                throw new Exception("No Steps Defined");
            }

            RaiseOnleaving();

            var nextIndex = position + 1;
            if (nextIndex >= steps.Count)
            {
                this.done(this);
                return;
            }

            var nextStep = steps[nextIndex];
            rootFrame.Navigate(nextStep.Page);
        }

        public void RemoveNextStep()
        {
            var nextStep = default(TStep);
            try
            {
                nextStep = steps[position + 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

            steps.Remove(nextStep);
            UpdateSteps();
        }

        public void RemoveStep(TStep step)
        {
            if (steps.Contains(step))
            {
                steps.Remove(step);
            }
        }

        private void RaiseOnleaving(NavigationMode mode = NavigationMode.Forward)
        {
            if (CurrentStep != null && CurrentStep.OnLeaving != null)
            {
                CurrentStep.OnLeaving(CurrentStep);
            }

            if (CurrentStep != null && CurrentStep.OnLeavingGoingBack != null)
            {
                CurrentStep.OnLeavingGoingBack(mode, CurrentStep);
            }
        }

        private void rootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                position--;
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                position++;
            }

            if (CurrentStep != null && CurrentStep.OnLoad != null)
            {
                CurrentStep.OnLoad(e.NavigationMode, CurrentStep);
            }
        }

        private void rootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                RaiseOnleaving(e.NavigationMode);
            }
        }

        private void UpdateSteps()
        {
            totalSteps = this.steps.Count;
            Steps = new ReadOnlyCollection<TStep>(this.steps);
        }
    }
}