
export interface KanjiEntry {
  literal: string
  radicalDecomposition: string[]
  codepoints: Codepoint[]
  strokePaths: string[]
  indexRadicals: IndexRadical[]
  isIndexRadical: boolean
  grade: Grade
  strokeCount: number
  strokeCommonMiscounts: any[]
  variants: Variant[]
  frequency?: number
  radicalNames: any[]
  jlpt?: number
  references: Reference[]
  queryCodes: QueryCode[]
  readings: Reading[]
  meanings: Meaning[]
  nanoris: string[]
}

export interface Codepoint {
  type: Type
  value: string
}

export interface Type {
  code: string
  description: string
  value: number
  displayName: string
}

export interface IndexRadical {
  type: Type2
  radical: string
  number: number
}

export interface Type2 {
  code: string
  value: number
  displayName: string
}

export interface Grade {
  number: number
  value: number
  displayName: string
}

export interface Variant {
  type: Type3
  value: string
}

export interface Type3 {
  code: string
  description: string
  value: number
  displayName: string
}

export interface Reference {
  type: Type4
  value: string
}

export interface Type4 {
  code: string
  description: string
  value: number
  displayName: string
}

export interface QueryCode {
  type: Type5
  skipMisclassification?: SkipMisclassification
  value: string
}

export interface Type5 {
  code: string
  description: string
  value: number
  displayName: string
}

export interface SkipMisclassification {
  code: string
  value: number
  displayName: string
}

export interface Reading {
  type: Type6
  value: string
}

export interface Type6 {
  code: string
  value: number
  displayName: string
}

export interface Meaning {
  language: Language
  term: string
}

export interface Language {
  threeLetterCode: string
  twoLetterCode: string
  value: number
  displayName: string
}
