<?php

    /**
     * Initialize the var of the game
     *
     * @return
     */
    function init(){}


        /**
         * Init the size of the secret code
         *
         * @return integer // size of the code that also the lenght of the board
         */
        function initCodeSize(): int{ return $x = 0; }


        /**
         * Init the number of try for this game
         *
         * @return integer // number of try wanted that also the height of the board
         */
        function initAttemptsNbr(): int{ return $y = 0; }


        /**
         * InitBoard create an empty board that will be printed each turn
         *
         * @param integer $x lenght / secret code size
         * @param integer $y height / number of try
         * @return array  // array of the board
         */
        function initBoard(int $x, int $y): array{ return $board = array(); }


        /**
         * Init the number of different value that can be in the code
         *
         * @return integer // number of value
         */
        function initColorNbr(): int{ return $nbColor = 0; }


        /**
         * Init a random secret code with code size and the number of different char
         *
         * @param integer $nbColor 
         * @param integer $codeSize
         * @return string $code generated code
         */
        function initCode(int $nbColor, int $codeSize): string{ return $code = "";}


    /**
     * Game loop
     *
     * @param array $board
     * @param integer $nbColor
     * @param string $code
     * @param integer $nbTry
     * @param integer $codeSize
     * @return void
     */
    function run(array $board, int $nbColor, int $code, int $nbTry, int $codeSize){}


        /**
         * Ask the user to enter a code and verify the compliance of it
         *
         * @param integer $nbColor
         * @param integer $codeSize
         * @return string $attempt last entry of the user
         */
        function userInput(int $nbColor, int $codeSize): string{ return $attempt= ""; }
        

        /**
         * Check how many correct colors at the good place and correct color at the wrong
         * place are in the attempt
         *
         * @param string $attempt
         * @param string $code
         * @return string // return the result of the attempt as a string
         */
        function checkInput(string $attempt, int $code): string{ return $result = "";}


        /**
         * Update the board with the last attempt, the attempts left and the result of the attempt
         *
         * @param string $attempt
         * @param string $result
         * @param array  $board
         * @return array $board updated board with the last attempt
         */
        function updateBoard(string $attempt, string $result, array $board): array{ return $board = array();}


        /**
         * Display the array of board as a correct board game (with all the attempts)
         *
         * @param array $board
         * @param string $result
         */
        function displayBoard(array $board,string $result){}


        /**
         * Check if the number of attemps is equal to 0 OR the last attempt is correct
         *
         * @param integer $nbTry
         * @param string $result
         * @return integer $final = 0 game continue, = 1 game winned, = 2 game lost
         */
        function checkWin(int $nbTry, string $result): int{ return $final = 0;}

               
    /**
     * Function called at the exit of the game loop, echo win or loose
     *
     * @param integer $final 
     */
    function endGame(int $final){}
