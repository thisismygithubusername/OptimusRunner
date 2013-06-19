using System.Collections.Generic;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class OptionModule
    {
        public OptionModule(Queue<string> args)
        {
            ParseOptions(args);
        }

        public OptionModule()
        {
            
        }

        public List<string> ExecutionValues
        {
            get; set;
        }

        /*
         * Checks if the path is in the correct index and points to valid assembly
         */
        //Todo
        public bool IsValidPath(Queue<string> args)
        {
            //if(che)
            ParseOptions(args);
            return true;
        }

        public string Path
        {
            get; set;
        }

        private void ParseOptions(Queue<string> args)
        {
            Path = args.Dequeue();
            this.ExecutionValues = new List<string>();
            ExecutionValues.AddRange(args);
        }

    }
}
