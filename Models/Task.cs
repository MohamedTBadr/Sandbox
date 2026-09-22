using Sandbox.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Models
{
    public class Task : BaseModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Deadline { get; private set; }

        public ApplicationUser User { get; private set; }

        public Guid UserId { get; private set; }

    
        public byte[] RowVersion { get; private set; }


        protected Task() { }







        private Task(
      string name,
      string description,
      DateTime deadline,
      Guid userId)
        {
            Id = Guid.NewGuid();

            SetName(name);
            SetDescription(description);
            SetDeadline(deadline);
            UserId = userId;
        }

        public static Task Create(
            string name,
            string description,
            DateTime deadline,
            Guid userId)
        {
            return new Task(
                name,
                description,
                deadline,
                userId);
        }


        public  void Update(string name, string description, DateTime deadline)
        {
            SetName(name);
            SetDescription(description);
            SetDeadline(deadline);
        }



        public void MarkAsDeleted()
        {
            DeletedAt = DateTime.UtcNow;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Task name cannot be empty.");
            }
            Name = name;
        }


        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Task description cannot be empty.");
            }
            Description = description;
        }

        private void SetDeadline(DateTime deadline)
        {
            if (deadline <= DateTime.UtcNow)
                throw new ArgumentException(
                    "Deadline must be in the future.");

            Deadline = deadline;
        }
    }
}
