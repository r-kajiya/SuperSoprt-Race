using System;
using Framework;

namespace SuperSport
{
    public class RegistUseCase : IUseCase
    {
        readonly RegistPresenter _presenter;
        Action _onDecision;

        public RegistUseCase(RegistPresenter presenter)
        {
            _presenter = presenter;
            _presenter.RegisterDecisionButton(Decision);
            _presenter.RegisterCloseButton(Close);
        }

        public bool CanOpen()
        {
            return false;
        }

        public void Open(Action onDecision)
        {
            _presenter.Open();
            _onDecision = onDecision;
        }

        public void Close()
        {
            _presenter.Close();
        }
        

        void Decision(string userName)
        {
            RegistUser(userName);
            _onDecision?.Invoke();
        }

        void RegistUser(string userName)
        {
            Network.SignInAnonymously(userId =>
            {
                // PlayerModel model = new PlayerModel(userId, userName,  PlayerEnvironment.DEFAULT_RACE_TIME, PlayerEnvironment.RANK_RACE_LEVEL);
                // PlayerRepository.I.Save(model);
            });
        }
        
        
    }
}