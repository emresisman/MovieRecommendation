using MovieRecommendation.Business.Request;

namespace MovieRecommendation.Business.Service.Interface
{
    public interface IRatingNoteService
    {
        void SetRatingToMovie(RatingRequest ratingRequest);
        void SetNoteToMovie(NoteRequest noteRequest);
    }
}