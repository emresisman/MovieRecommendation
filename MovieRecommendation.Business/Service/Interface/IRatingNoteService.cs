using MovieRecommendation.Business.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IRatingNoteService
    {
        void SetRatingToMovie(RatingRequest ratingRequest);
        void SetNoteToMovie(NoteRequest noteRequest);
    }
}