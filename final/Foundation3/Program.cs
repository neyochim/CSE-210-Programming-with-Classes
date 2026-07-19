using System;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Main Street", "Provo", "UT", "USA");
        Address receptionAddress = new Address("456 Oak Avenue", "Salt Lake City", "UT", "USA");
        Address outdoorAddress = new Address("789 Pine Road", "Boise", "ID", "USA");

        LectureEvent lectureEvent = new LectureEvent(
            "Programming with Classes",
            "A discussion on object-oriented programming principles.",
            "June 20, 2026",
            "6:00 PM",
            lectureAddress,
            "Brother Smith",
            150);

        ReceptionEvent receptionEvent = new ReceptionEvent(
            "Annual Company Reception",
            "An evening reception for employees and partners.",
            "July 5, 2026",
            "7:30 PM",
            receptionAddress,
            "events@company.com");

        OutdoorGatheringEvent outdoorEvent = new OutdoorGatheringEvent(
            "Summer Concert in the Park",
            "A family-friendly outdoor concert with local artists.",
            "August 12, 2026",
            "8:00 PM",
            outdoorAddress,
            "Sunny with a light breeze and clear skies.");

        Console.WriteLine("Lecture Event");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception Event");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering Event");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}

class Address
{
    private string _ney_Street;
    private string _ney_City;
    private string _ney_State;
    private string _ney_Country;

    public string ney_Street
    {
        get => _ney_Street;
        private set => _ney_Street = value;
    }

    public string ney_City
    {
        get => _ney_City;
        private set => _ney_City = value;
    }

    public string ney_State
    {
        get => _ney_State;
        private set => _ney_State = value;
    }

    public string ney_Country
    {
        get => _ney_Country;
        private set => _ney_Country = value;
    }

    public Address(string street, string city, string state, string country)
    {
        _ney_Street = street;
        _ney_City = city;
        _ney_State = state;
        _ney_Country = country;
    }

    public string GetFullAddress()
    {
        return $"{_ney_Street}, {_ney_City}, {_ney_State}, {_ney_Country}";
    }
}

class Event
{
    private string _ney_Title;
    private string _ney_Description;
    private string _ney_Date;
    private string _ney_Time;
    private Address _ney_Address;

    public string ney_Title
    {
        get => _ney_Title;
        private set => _ney_Title = value;
    }

    public string ney_Description
    {
        get => _ney_Description;
        private set => _ney_Description = value;
    }

    public string ney_Date
    {
        get => _ney_Date;
        private set => _ney_Date = value;
    }

    public string ney_Time
    {
        get => _ney_Time;
        private set => _ney_Time = value;
    }

    public Address ney_Address
    {
        get => _ney_Address;
        private set => _ney_Address = value;
    }

    public Event(string title, string description, string date, string time, Address address)
    {
        _ney_Title = title;
        _ney_Description = description;
        _ney_Date = date;
        _ney_Time = time;
        _ney_Address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_ney_Title}\nDescription: {_ney_Description}\nDate: {_ney_Date}\nTime: {_ney_Time}\nAddress: {_ney_Address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: {GetEventType()}";
    }

    public virtual string GetShortDescription()
    {
        return $"{GetEventType()}: {_ney_Title} - {_ney_Date}";
    }

    protected virtual string GetEventType()
    {
        return "Event";
    }
}

class LectureEvent : Event
{
    private string _ney_SpeakerName;
    private int _ney_Capacity;

    public string ney_SpeakerName
    {
        get => _ney_SpeakerName;
        private set => _ney_SpeakerName = value;
    }

    public int ney_Capacity
    {
        get => _ney_Capacity;
        private set => _ney_Capacity = value;
    }

    public LectureEvent(string title, string description, string date, string time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        _ney_SpeakerName = speakerName;
        _ney_Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {_ney_SpeakerName}\nCapacity: {_ney_Capacity}";
    }

    protected override string GetEventType()
    {
        return "Lecture";
    }
}

class ReceptionEvent : Event
{
    private string _ney_RsvpEmail;

    public string ney_RsvpEmail
    {
        get => _ney_RsvpEmail;
        private set => _ney_RsvpEmail = value;
    }

    public ReceptionEvent(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _ney_RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {_ney_RsvpEmail}";
    }

    protected override string GetEventType()
    {
        return "Reception";
    }
}

class OutdoorGatheringEvent : Event
{
    private string _ney_WeatherStatement;

    public string ney_WeatherStatement
    {
        get => _ney_WeatherStatement;
        private set => _ney_WeatherStatement = value;
    }

    public OutdoorGatheringEvent(string title, string description, string date, string time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        _ney_WeatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {_ney_WeatherStatement}";
    }

    protected override string GetEventType()
    {
        return "Outdoor Gathering";
    }
}