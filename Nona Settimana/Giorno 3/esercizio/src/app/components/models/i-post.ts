  //interfaccia per la gestione dei post
export interface iPost {
  id: number
  title: string
  body: string
  userId: number
  tags: string[]
  active: boolean
}
