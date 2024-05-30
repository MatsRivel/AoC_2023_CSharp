namespace AoC_2023_07
{
    public enum CardType
    {
        Queen   =13,
        King    =12,
        Knight  =11,
        Ten     =10,
        Nine    = 9,
        Eight   = 8,
        Seven   = 7,
        Six     = 6,
        Five    = 5,
        Four    = 4,
        Three   = 3,
        Two     = 2,
        Ace     = 1,
    }
    public static class CardTypeMethods
    {
        public static CardType CharToCardtype(char cardChar)
        {
            return cardChar switch
            {
                'Q' => CardType.Queen,
                'K' => CardType.King,
                'J' => CardType.Knight,
                'T' => CardType.Ten,
                '9' => CardType.Nine,
                '8' => CardType.Eight,
                '7' => CardType.Seven,
                '6' => CardType.Six,
                '5' => CardType.Five,
                '4' => CardType.Four,
                '3' => CardType.Three,
                '2' => CardType.Two,
                'A' => CardType.Ace,
                _ => throw new ArgumentException("Invalid card character."),
            };
        }
        public static char CardTypeToChar(CardType cardType)
        {
            return cardType switch
            {
                CardType.King   => 'K',
                CardType.Queen  => 'Q',
                CardType.Knight => 'J',
                CardType.Ten    => 'T',
                CardType.Nine   => '9',
                CardType.Eight  => '8',
                CardType.Seven  => '7',
                CardType.Six    => '6',
                CardType.Five   => '5',
                CardType.Four   => '4',
                CardType.Three  => '3',
                CardType.Two    => '2',
                CardType.Ace    => 'A',
                _ => throw new ArgumentException("Invalid card type."),
            };
        }
    }
}
