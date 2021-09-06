using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class MessageService : IMessageService
    {
        private readonly DataContext context;
        private readonly ILogger logger;

        public MessageService(ILogger logger)
        {
            this.context = new DataContext();
            this.logger = logger;
        }

        public Message Add(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            context.Set<Message>().Add(message);
            context.SaveChanges();

            logger.write($"Create message {message.Id}");
            return message;
        }

        public void Delete(int id)
        {
            var entity = context.Set<Message>().Single(x=>x.Id == id);
            context.Set<Message>().Remove(entity);
            context.SaveChanges();

            logger.write($"Delete message {id}");
        }

        public IEnumerable<Message> Get(int userId)
        {
            if (userId <= 0)
                throw new ArgumentNullException(nameof(userId));

            return context.Set<Message>()
                .Include(x => x.Sender)
                .Where(x => x.SenderId == userId);
        }

        public IEnumerable<Message> GetAll()
        {
            return context.Set<Message>().ToList();
        }

        public Message GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return context.Set<Message>()
                .Include(x => x.Sender)
                .Single(x => x.Id == id);
        }
    }
}
