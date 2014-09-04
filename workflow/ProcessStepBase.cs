//-----------------------------------------------------------------------
// <copyright file="ProcessStepBase.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.workflow
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public class ProcessStepBase
    {
        public ProcessStepBase(Type page)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }

            this.Page = page;
        }

        public Action<ProcessStepBase> OnLeaving { get; set; }

        public Action<NavigationMode, ProcessStepBase> OnLeavingGoingBack { get; set; }

        public Action<NavigationMode, ProcessStepBase> OnLoad { get; set; }

        public Type Page { get; private set; }

        public static implicit operator ProcessStepBase(Type page)
        {
            return new ProcessStepBase(page);
        }

        public override string ToString()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return string.Empty;
            }

            return Page.FullName;
        }
    }
}