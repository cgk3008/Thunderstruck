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
        public bool IsSearchAreaVisible { get; set; }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                    Get();
                    break;

                case "search":
                    Get();
                    break;

                case "resetentry":
                    ResetSearch();
                    Get();
                    break;

                case "edit":
                    //System.Diagnostics.Debugger.Break(); used this code to stop and lok at code and inspect web page
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "add":
                    Add();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                default:
                    break;
            }

        }

        protected virtual void ListMode() //moved from TrainingProdcutViewModel changed from private to protected so we can inherit from it, and virtual so we can override it.
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void ResetSearch()
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
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }

        }

        protected virtual void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        protected virtual void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
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

        protected virtual void Add()
        {
            AddMode();
        }

        protected virtual void Edit()
        {
            EditMode();
        }

        protected virtual void Delete()
        {

            //Get();  we could add this
            ListMode();
        }


    }
}