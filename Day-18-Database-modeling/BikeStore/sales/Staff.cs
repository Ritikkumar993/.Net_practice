class Staff
{
    public int StaffId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public int StoreId { get; set; }
    public Store Store{get; set;}=null;
    public string ManageId {get; set; }
    public Staff Manager{get; set; }= null;



}