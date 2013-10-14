using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBotPlugin;

namespace numericfunc
{
    class numericfunction : IUBotFunction
    {
        // List to hold the parameters we define for our command.
        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();
        private string _returnValue;

        public numericfunction()
        {
            // Add our parameter (Alert Text) with a String type since it is text.
            _parameters.Add(new UBotParameterDefinition("Value Numeric?", UBotType.String));
            //_parameters.Add(new UBotParameterDefinition("Display message", UBotType.String));

        }

        public string Category
        {
            // This is what category our command is categorized as. 
            // If you choose something not already in the toolbox list, a new category will be created.
            get { return "Text Functions"; }
        }

        public string FunctionName
        {
            // The name of our node in UBot Studio.
            get { return "$numeric value"; }
        }
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {
            // Grab the value of the Alert Text parameter we defined.
            string numberString = parameters["Value Numeric?"];
            //var displaymessage = parameters["Display message"].ToLower();

            // Display the MessageBox with an error icon and the text given.
            //if (displaymessage.ToLower() == "yes")
            //{
            //    MessageBox.Show(value, "Error Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.ShowDialog();
            //string selected = dialog.SelectedPath;
            decimal numericval = 0;
            bool canConvert = decimal.TryParse(numberString, out numericval);
            if (canConvert)
            {
                //Console.WriteLine("number3 = {0}", numericval);
                _returnValue = "true";
            }
            else
            {
                //Console.WriteLine("numString is not a valid decimal");
                _returnValue = "false";
            }
        }

        public bool IsContainer
        {
            // This command does not have any nested commands inside of it, so it is not a container command.
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            // We reference our parameter list we defined above here.
            get { return _parameters; }
        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public UBotVersion UBotVersion
        {
            // This is the lowest version of UBot Studio that this command can run in.
            get { return UBotVersion.Standard; }
        }
    }
}
