using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thunderstruck
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();

        }
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsCalculationAreaVisible { get; set; }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                //case "list":
                //    Get();
                //    break;

                //case "search":
                //    Get();
                //    break;

                case "resetentry":
                    ResetEntry();
                    Get();
                    break;

                //case "edit":
                //    //System.Diagnostics.Debugger.Break(); used this code to stop and lok at code and inspect web page
                //    IsValid = true;
                //    Edit();
                //    break;

                //case "delete":
                //    ResetSearch();
                //    Delete();
                //    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "calc":
                    Calc();
                    break;

                //case "cancel":
                //    ListMode();
                //    Get();
                //    break;

                default:
                    break;
            }

        }

        protected virtual void ListMode() //moved from TrainingProdcutViewModel changed from private to protected so we can inherit from it, and virtual so we can override it.
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsCalculationAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void ResetEntry()
        {

        }

        protected virtual void Save()
        {

            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Calc")
                {
                    CalcMode();
                }
                else
                {
                    EditMode();
                }
            }

        }

        protected virtual void CalcMode()
        {
            IsListAreaVisible = false;
            IsCalculationAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "Calc";
        }

        protected virtual void EditMode()
        {
            IsListAreaVisible = false;
            IsCalculationAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;

            ValidationErrors = new List<KeyValuePair<string, string>>();
            ListMode();

        }

        protected virtual void Get()
        {

        }

        protected virtual void Calc()
        {
            //function thunder()
            //{
            //    var value1 = Number(document.getElementById("fThunder").value);

            //    var drinker1 = 0;
            //    var drinker2 = 0;
            //    var drinker3 = 0;
            //    var result = 0;

            //    for (i = 1; i <= value1; i++)
            //    {

            //        if (value1 <= 1)
            //        {
            //            return result = "Enter number from 2 to 34."
            //        }

            //        if (16 % value1 === 0)
            //        {
            //            drinker1 = value1;
            //        }

            //        if (20 % value1 === 0)
            //        {
            //            drinker2 = value1;
            //        }

            //        if (24 % value1 === 0)
            //        {
            //            drinker3 = value1;
            //        }



            //    }



            //    document.getElementById("result").innerHTML = result;

            //}


            CalcMode();            
        }

        protected virtual void Edit()
        {
            EditMode();
        }

        //protected virtual void Delete()
        //{

        //    //Get();  we could add this
        //    ListMode();
        //}


    }
}