lsof -ti tcp:5700 | xargs kill & lsof -ti tcp:5701 | xargs kill & lsof -ti tcp:5702 | xargs kill & lsof -ti tcp:5100 | xargs kill
