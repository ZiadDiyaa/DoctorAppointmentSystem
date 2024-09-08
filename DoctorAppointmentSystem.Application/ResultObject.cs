namespace DoctorAppointmentSystem.Application;

public class ResultObject<T>{

public ResultObject() => Messages = new List<MessageModel>();

public ResultObject(T body)
{
    Messages = new List<MessageModel>();
    this.Result = body;
}

public bool Succeeded { get; set; } = false;

public T Result { get; set; }

public List<MessageModel> Messages { get; set; }

public void AddMessage(MessageModel messageModel)
{
    Messages.Add(messageModel);
}

public void AddMessage(MessageType messageType, string message)
{
    Messages.Add(new MessageModel(messageType, message));
}

public void CloneMessages(List<MessageModel> messages)
{
    messages.ForEach(msg => {
        Messages.Add(msg);
    });
}

public int MessagesCount
{
    get { return Messages.Count; }
}
}

public class MessageModel
{
    
    public MessageModel(MessageType messageType, string message)
    {
        this.MessageType = messageType;
        this.Message = message;
    }

    public MessageType MessageType { get; set; }

    public string Message { get; set; }
}

public enum MessageType
{
    FriendlyMessage = 0,
    LogicalError = 1,
    Exception = 2
}
