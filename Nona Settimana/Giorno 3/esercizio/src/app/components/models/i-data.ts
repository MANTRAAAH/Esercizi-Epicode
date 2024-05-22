import { iPost } from "../models/i-post";

export interface iData {
  posts: iPost[]
  total: number
  skip: number
  limit: number
}
