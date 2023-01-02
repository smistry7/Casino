use CasinoDatabase;

Begin transaction

insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('fa20cd73-d1b0-49d9-83ae-00bc661a607d', 'omcgragh0', '008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 17.08, 0.56, '10/4/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('cb650762-88ec-473f-90e6-fed3e5c63b1c', 'ntremellan1', '008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 202.61, 0.7, '4/13/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('c7a85a6a-b044-45fe-8c8c-61db11826d31', 'jcharge2','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 717.37, 0.65, '12/16/2021');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('397603c1-ca26-40b9-9159-726a0fa14400', 'rgroombridge3', '008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' ,415.83, 0.95, '4/10/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('1559a653-82a6-4e1b-a6e1-5890f6a04b88', 'sfinn4','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 554.82, 0.45, '5/17/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('c19f5b90-a733-4055-b114-33ba12262293', 'mdinse5','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 196.97, 0.82, '8/19/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('cbe4665e-a2ee-46e6-ae90-48e339cc9500', 'bbexley6','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 456.76, 0.92, '11/19/2021');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('05d3463c-1fd1-4ec0-a9fd-0b804583fd1e', 'edrejer7','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 869.08, 0.66, '11/10/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('d60a1c46-679e-48b2-b39b-b9deb45703ac', 'smatuska8','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 794.72, 0.41, '8/9/2022');
insert into dbo.UserAccount (id, Username, PasswordHash, balance, LuckCoefficient, DateJoined) values ('8dc07f18-4dd6-4629-b393-2d319652819c', 'pdurno9','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601' , 888.10, 0.83, '4/13/2022');


insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('11ba6d9c-c771-4717-acc6-8d0aaf93b16c', 'fa20cd73-d1b0-49d9-83ae-00bc661a607d', 'Blackjack', 55.19, 0.00, 0.52,0);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('165ff721-c9fb-4e14-bcf6-eb5ba7e7f357', 'fa20cd73-d1b0-49d9-83ae-00bc661a607d', 'Blackjack', 94.25, 71.2, 0.09,1);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('d2115aa9-375d-49c7-8386-ab26cb834bb3', 'fa20cd73-d1b0-49d9-83ae-00bc661a607d', 'Blackjack', 47.71, 64.88, 0.42,1);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('8f5dc560-1e01-4b8d-a776-5fb25dd958c6', 'fa20cd73-d1b0-49d9-83ae-00bc661a607d', 'Blackjack', 71.2, 0.00, 0.17,0);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('f520da11-7bbc-4981-9740-4e3cad81571b','1559a653-82a6-4e1b-a6e1-5890f6a04b88',  'Blackjack', 59.11, 76.31, 0.36, 1);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('3675732e-e4ee-4454-9871-c9ebe4066f7c','1559a653-82a6-4e1b-a6e1-5890f6a04b88',  'Blackjack', 12.41, 38.31, 0.11, 1);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('ae23e3c4-7aa8-47dc-ad37-29ce5384235c', '8dc07f18-4dd6-4629-b393-2d319652819c', 'Blackjack', 47.39, 0.00, 0.05, 0);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('059b645f-cc1e-439b-8cf1-400fe5428051', '8dc07f18-4dd6-4629-b393-2d319652819c', 'Blackjack', 97.86, 0.00, 0.58, 0);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('5df0c7e7-8102-46a1-a22b-fee5ed0db978', '8dc07f18-4dd6-4629-b393-2d319652819c', 'Blackjack', 7.75, 58.0, 0.3, 1);
insert into dbo.GameRecord (GameId, UserId, GameType, AmountStaked, AmountWon, WinProbability, DidPlayerWin) values ('e97caa4e-60d3-4876-b894-e54b18c398bc', '8dc07f18-4dd6-4629-b393-2d319652819c', 'Blackjack', 36.07, 0.00, 0.92,0);


commit transaction;
