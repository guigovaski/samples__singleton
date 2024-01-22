namespace Singleton;

/*
 * Tornar a classe selada garante que nenhuma classe possa herdar dessa classe e consequentemente instancia-la 
 */
public sealed class Singleton
{
    private static readonly object InstanceLock = new();
    private static Singleton? _instance;

    public static Singleton Instance
    {
        get
        {
            if (_instance is null)
            {
                /*
                 * Para evitar problemas de concorrencia ao obter a primeira instancia da classe (em um ambiente multi-threading)
                 */
                lock (InstanceLock)
                {
                    if (_instance is null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
}
