using System.ComponentModel.DataAnnotations;


namespace UserManagementCommon
{
    public class User
    {

        [Key]
        public int Id 
        {   get;
            set; 
        } 

       
        public string firstName
        {
            get;
            set;
        } = String.Empty;

        public string lastName
        {

            get;
            set;
        } = String.Empty;

        public bool activepassive
        {
            get;
            set;
        } = false;
        public string email
        {

            get;
            set;
        } = String.Empty;
        public string address
        {

            get;
            set;
        } = String.Empty;
        public string telNo
        {
            get;
            set;
        } = String.Empty;

        public DateTime? Date
        {
            get; 
            set;
        } = DateTime.Now;
    }
}