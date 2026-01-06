class Button
{
    //delegate 
    public delegate void ClickHandler();

    public event ClickHandler Clicked;

    public void Click()
    {
        Clicked?.Invoke();
    }
}