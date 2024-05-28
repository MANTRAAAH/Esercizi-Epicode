import { iPost } from "../models/i-post";
//deprecata, sostituita da iPost
export interface iData {
  posts: iPost[]
  total: number
  skip: number
  limit: number
}
