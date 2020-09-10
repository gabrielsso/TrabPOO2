public interface IDeliveryService
{
    string name
    {
        get;
        set;
    }

    void Deliver(int cod_ped, string destination, string client_name);
}