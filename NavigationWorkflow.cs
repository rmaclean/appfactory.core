namespace appfactory.core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;     

    public class NavigationWorkflow
    {
        private object lastParameter;
        private static NavigationWorkflow instance = new NavigationWorkflow();
        private string currentState = "";
        private Dictionary<string, Func<object, WorkflowResult>> steps;

        private NavigationWorkflow()
        {
        }

        public static NavigationWorkflow Instance
        {
            get
            {
                return instance;
            }
        }

        public void Configure(Dictionary<string, Func<object, WorkflowResult>> steps, object firstStepParameter = null)
        {
            if (firstStepParameter != null)
            {
                lastParameter = firstStepParameter;
            }

            this.steps = steps;
            Next();
        }

        public void Next()
        {
            var action = steps[currentState];
            var result = action(lastParameter);
            lastParameter = result.Parameter;
            currentState = result.Step;
        }        
    }

    public class WorkflowResult
    {
        public string Step { get; private set; }
        public object Parameter { get; private set; }

        public static implicit operator WorkflowResult(string step)
        {
            return new WorkflowResult(step, null);
        }

        public WorkflowResult(string step, object parameter)
        {
            this.Step = step;
            this.Parameter = parameter;
        }
    }
}