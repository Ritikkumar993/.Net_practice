//  (ID, name, age, contact, medical history).

class Patient
{

    public int PatientId{ get;}
    public string? Name{get; set;}
    private int age{get;set;}
    private int ID;   
   
    private int contact;
    private string? medicalHistory;

    public Patient(int id,string name, int age)
    {
        PatientId=id;
        Name=name;
        this.age=age;
        
    }

    public void SetMedicalHistory(string history)
    {
        this.medicalHistory=history;
    }
    public string GetMedicalHistory()
    {
        return medicalHistory;
    }
}