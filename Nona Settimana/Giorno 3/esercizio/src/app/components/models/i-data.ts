import { IPost } from "../models/i-post";

export interface iData {
  posts: IPost[]
  total: number
  skip: number
  limit: number
}
