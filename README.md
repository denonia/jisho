# 辞書

A tiny words/kanji dictionary (JMdict, Jitendex, KANJIDIC) and sentence aggregator (Tatoeba, Reverso, Weblio)

### Setting up
* Get Jitendex dictionary from the [official website](https://jitendex.org/pages/downloads.html) (Yomitan format)
* Refer to `docker-compose.yml.example` to configure the containers
* Set up API routes at `jisho-client/src/environments/environment.ts`
* Run in Docker `docker-compose up --build -d`