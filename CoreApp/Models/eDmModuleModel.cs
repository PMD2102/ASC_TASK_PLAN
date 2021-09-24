using System;
namespace CoreApp.Models
{
    public class eDmModuleModel
    {
        public eDmModuleModel()
        {
        }

        public eDmModuleModel(int Id, string TenModule)
        {
            this.Id = Id;
            this.TenModule = TenModule;
        }
        
        public int Id { get; set; }

        public string TenModule { get; set; }

       
    }
}
