# Hangman API Project:

You need to run the existing migrations to generate the data structure, the migrations are on the Infra project.

## Endpoints
- Retrieve random word to guess per difficulty: (GET) `http://localhost:5102/api/words?difficulty={DIFICULTY_NUMBER}` 
	example: `http://localhost:5102/api/words?difficulty=1`, default `1`

- Create new player: (POST) `http://localhost:5102/api/players`
	example:
	```json
	{
	  "nickname": "string"
	}
	```

- Retrieve existing player: (GET) `http://localhost:5102/api/players/{PLAYER_ID}` 
	example: `http://localhost:5102/api/players/3fa85f64-5717-4562-b3fc-2c963f66afa6`

- Initialize new game: (POST) `http://localhost:5102/api/games`
	example:
	```json
	{
	  "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
	  "gameDifficulty": 0
	}
	```

- Get existing game: (GET) `http://localhost:5102/api/games/{GAME_ID}`
	example: `http://localhost:5102/api/games/3fa85f64-5717-4562-b3fc-2c963f66afa6`

- Active game: (PATCH) `http://localhost:5102/api/games/{GAME_ID}/active`
	example: `http://localhost:5102/api/games/3fa85f64-5717-4562-b3fc-2c963f66afa6/active`

- Make Word Guess Attempt: (POST) `http://localhost:5102/api/games/{GAME_ID}/guess`
	example: `http://localhost:5102/api/games/3fa85f64-5717-4562-b3fc-2c963f66afa6/guess`
	```json
	{
	  "characterToGuess": "a"
	}
	```

- Retrieve Score Leaderboard: (GET) `http://localhost:5102/api/scores?difficulty={DIFF_NUMBER}&page={PAGE}&size={NUMBER}`
	example: `http://localhost:5102/api/scores?difficulty=2&page=1&size=20`


## Game flow:

- Create Player
- Initialize new Game
- Active Game
- Make Guess Attempt


