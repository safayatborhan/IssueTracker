using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface IChat
    {
        IEnumerable<Message> GetAll();
        void AddMessage(Message message);
    }
}
