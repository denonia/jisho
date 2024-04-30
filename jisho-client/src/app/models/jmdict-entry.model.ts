export interface JmdictEntry {
  sequence: number
  kanjis: Kanji[]
  readings: Reading[]
  senses: Sense[]
}

export interface Kanji {
  text: string
  informations: Information[]
  priorities: Priority[]
}

export interface Information {
  code: string
  value: number
  displayName: string
}

export interface Priority {
  code: string
  value: number
  displayName: string
}

export interface Reading {
  text: string
  isTrueKanjiReading: boolean
  restriction: any[]
  informations: any[]
  priorities: Priority2[]
}

export interface Priority2 {
  code: string
  value: number
  displayName: string
}

export interface Sense {
  kanjiRestriction: any[]
  readingRestriction: string[]
  partsOfSpeech: PartsOfSpeech[]
  crossReferences: string[]
  antonyms: any[]
  fields: Field[]
  miscellanea: Miscellanea[]
  informations: any[]
  loanwordSources: any[]
  dialects: any[]
  glosses: Gloss[]
}

export interface PartsOfSpeech {
  code: string
  description: string
  value: number
  displayName: string
}

export interface Field {
  code: string
  value: number
  displayName: string
}

export interface Miscellanea {
  code: string
  value: number
  displayName: string
}

export interface Gloss {
  term: string
  language: Language
  type: any
  gender: any
}

export interface Language {
  threeLetterCode: string
  twoLetterCode: string
  value: number
  displayName: string
}
