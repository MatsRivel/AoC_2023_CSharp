namespace AoC_2023_07
{
    public record struct HandInfo(string Cards, int Bet)
    {
        public static implicit operator (string, int)(HandInfo value)
        {
            var s= value.Cards
                .Aggregate("", (agg, c) => agg + c);
            return (s, value.Bet);
        }

        public static implicit operator HandInfo((string, int) value)
        {   
            return new HandInfo(value.Item1, value.Item2);
        }
        public static CardType[] IntoCardType( HandInfo handInfo )
        {
            return handInfo.Cards.Select(c => CardTypeMethods.CharToCardtype(c)).ToArray();
        }
    }
}
