using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OrganizationUser
{
    class StatusComparisonTrigger : StateTriggerBase
    {
        public const string Equal = "Equal";
        public const string NotEqual = "NotEqual";

        public string DataValue
        {
            get { return (string)GetValue(DataValueProperty); }
            set
            {
                SetValue(DataValueProperty, value);
            }
        }
        public readonly DependencyProperty DataValueProperty = DependencyProperty.Register(nameof(DataValue), typeof(string), typeof(StatusComparisonTrigger), new PropertyMetadata(Equal, (s, e) =>
           {
               var statusTrigger= s as StatusComparisonTrigger;
               CheckTriggerStatus(statusTrigger,statusTrigger.TriggerValue,(string)e.NewValue);
           }));

        public string TriggerValue
        {
            get { return (string)GetValue(TriggerValueProperty); }
            set
            {
                SetValue(TriggerValueProperty, value);
            }
        }
        public readonly DependencyProperty TriggerValueProperty = DependencyProperty.Register(nameof(TriggerValue), typeof(string), typeof(StatusComparisonTrigger), new PropertyMetadata(Equal, (s, e) =>
         {
             var statusTrigger=s as StatusComparisonTrigger;
             //CheckTriggerStatus(statusTrigger, statusTrigger.DataValue, (string)e.NewValue);
         }));
        private static void CheckTriggerStatus(StatusComparisonTrigger statusComparisonTrigger,string dataValue,string triggerValue)
        {
            statusComparisonTrigger.SetActive(dataValue==triggerValue);
        }
    }
}
