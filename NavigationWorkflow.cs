namespace appfactory.core
{
    using System;
    using System.Collections.Generic;

    public class NavigationWorkflow
    {
        private static NavigationWorkflow instance = new NavigationWorkflow();
        private Dictionary<string, Func<object, WorkflowResult>> steps;

        private NavigationWorkflow()
        {
            CurrentStep = "";
        }

        public static NavigationWorkflow Instance
        {
            get
            {
                return instance;
            }
        }

        public string CurrentStep { get; set; }

        public object Parameter { get; set; }

        public void Configure(Dictionary<string, Func<object, WorkflowResult>> steps, object firstStepParameter = null)
        {
            if (firstStepParameter != null)
            {
                Parameter = firstStepParameter;
            }

            this.steps = steps;
            Next();
        }

        public void Next()
        {
            var action = steps[CurrentStep];
            var result = action(Parameter);
            CurrentStep = result.Step;
        }
    }

    public class WorkflowResult
    {
        public WorkflowResult(string step, object parameter)
        {
            this.Step = step;
        }

        public string Step { get; private set; }

        public static implicit operator WorkflowResult(string step)
        {
            return new WorkflowResult(step, null);
        }
    }
}