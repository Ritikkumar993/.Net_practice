//  (ID, name, age, contact, medical history).

class Patient
{
    private int ID;   
   
    private int contact;
    private string medicalHistory;

    public int PatientId{ get{return ID;}}
    public string Name{get; set;}
    private int age{get;set;}
    public Patient(int id)
    {
        this.ID=id;
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