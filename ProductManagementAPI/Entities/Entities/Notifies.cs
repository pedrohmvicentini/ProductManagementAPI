﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            Notifications = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; } = string.Empty;
        [NotMapped]
        public string Message { get; set; } = string.Empty;
        [NotMapped]
        public bool Error { get; set; } = false;
        [NotMapped]
        public List<Notifies> Notifications { get; set; }


        public bool ValidateStringValue(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName,
                    Error = true
                });

                return false;
            }
            return true;
        }

        public bool ValidateIntValue(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName,
                    Error = true
                });

                return false;
            }
            return true;
        }

        public bool ValidateDateValue(DateTime? value, string propertyName)
        {
            if (value == null || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName,
                    Error = true
                });

                return false;
            }
            return true;
        }

        public bool ValidateBetweenTwoDateValue(DateTime? value, DateTime? valueCompare, string propertyName, string message)
        {
            if (value != null && valueCompare != null)
            {
                if (value >= valueCompare)
                {
                    Notifications.Add(new Notifies
                    {
                        Message = message,
                        PropertyName = propertyName,
                        Error = true
                    });

                    return false;
                }
                else
                    return true;
            }
            return false;
        }
    }
}
