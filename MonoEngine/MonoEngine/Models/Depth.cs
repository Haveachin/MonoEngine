namespace MonoEngine.Models
{
    public class Depth
    {
        private int value;

        public static implicit operator Depth(int Value) => new Depth { value = Value };

        public static implicit operator int(Depth Depth) => Depth?.value ?? 0;
    }
}
