namespace CoreApp.Models
{
    public class TestModel
    {

       

        public TestModel(string id, int soGio, float hoanThanh){
            this.id = id;
            this.soGio = soGio;
            this.hoanThanh = hoanThanh;
        }

        public string id {get; set;}

        public int soGio {get; set;}

        public float hoanThanh {get;set;}
    }
}