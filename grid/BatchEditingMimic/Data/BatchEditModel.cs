using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchEditingMimic.Data
{
    public class BatchEditModel : Employee
    {
        // used for batch editing logic only, so they need to be part of the view model only
        public bool IsDeleted { get; set; }
        public bool IsChanged { get; set; }
        public bool IsNew { get; set; }
        public bool IsDirty
        {
            get
            {
                return this.IsDeleted || this.IsChanged || this.IsNew;
            }
        }

        // actual fields are inherited from an actual model
        // An inner field with type injection is not used because it will nest fields in the grid model and
        // this does not work yet: https://feedback.telerik.com/blazor/1432615-support-for-nested-complex-models
        // ideally the view model will be typed according to the Employee model instead of using inheritance
        // and the grid columns will then use Field=@nameof(BatchEditModel.Model.Age) 
    }
}
