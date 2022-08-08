public class TopMenu
{
    public TopMenuItem[] MenuItems { get; set; }
}

public class GenericMenu
{
    public MenuItem[] MenuItems { get; set; }
}

public class MenuItem
{
    public string Title { get; set; }
    public string Path { get; set; }
    
}

public class TopMenuItem : MenuItem
{
    public MenuItem[] Children { get; set; }
}


