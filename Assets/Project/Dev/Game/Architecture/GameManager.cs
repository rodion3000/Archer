
using Zenject;

public class GameManager
{
    private SoundManager _soundManager;
    private GameEffect _gameEffect;

    [Inject]
    private void Construct(SoundManager soundManager, GameEffect gameEffect)
    {
        _soundManager = soundManager;
        _gameEffect = gameEffect;
    }
    
}
