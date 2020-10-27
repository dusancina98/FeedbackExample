using FeedbackExample.Contracts.DTO;
using FeedbackExample.Contracts.IdentifiableDTO;
using FeedbackExample.Contracts.Interfaces;
using FeedbackExample.Entities;
using FeedbackExample.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedbackExample.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public Guid Create(FeedbackDTO entityDTO)
        {
            Feedback feedback = CreateFeedbackFromDTO(entityDTO);

            _feedbackRepository.Create(feedback);

            return feedback.Id;
        }

        public bool Delete(Guid id) => _feedbackRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetAll()
            => _feedbackRepository.GetAll().Select(c => CreateDTOFromFeedback(c));


        public IdentifiableDTO<FeedbackDTO> GetById(Guid id) => CreateDTOFromFeedback(_feedbackRepository.GetById(id));

        public void Update(FeedbackDTO entityDTO, Guid id)
        {
            _feedbackRepository.Update(CreateFeedbackFromDTO(entityDTO, id));

        }

        private Feedback CreateFeedbackFromDTO(FeedbackDTO feedback, Guid? id = null)
            => id == null ? new Feedback(feedback.Comment, feedback.Grade, feedback.GradedUserId)
                          : new Feedback(id.Value, feedback.Comment, feedback.Grade, feedback.GradedUserId);


        private IdentifiableDTO<FeedbackDTO> CreateDTOFromFeedback(Feedback feedback)
        {
            if (feedback == null) return null;

            return new IdentifiableDTO<FeedbackDTO>()
            {
                Id = feedback.Id,
                EntityDTO = new FeedbackDTO()
                {
                   Comment = feedback.Comment,
                   Grade = feedback.Grade,
                   GradedUserId = feedback.GradedUserId
                }

            };
        }
    }
}
