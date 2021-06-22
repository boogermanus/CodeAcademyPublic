import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class BlogService {
  blogs = [
    {
      userId: 1,
      id: 1,
      title: 'sunt aut facere repellat provident occaecati excepturi optio reprehenderit',
      // tslint:disable-next-line: max-line-length
      body: 'quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto'
    },
    {
      userId: 1,
      id: 2,
      title: 'qui est esse',
      // tslint:disable-next-line: max-line-length
      body: 'est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla'
    },
    {
      userId: 1,
      id: 3,
      title: 'ea molestias quasi exercitationem repellat qui ipsa sit aut',
      // tslint:disable-next-line: max-line-length
      body: 'et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut'
    },
    {
      userId: 1,
      id: 4,
      title: 'eum et est occaecati',
      // tslint:disable-next-line: max-line-length
      body: 'ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa\nquis hic commodi nesciunt rem tenetur doloremque ipsam iure\nquis sunt voluptatem rerum illo velit'
    },
    {
      userId: 1,
      id: 5,
      title: 'nesciunt quas odio',
      // tslint:disable-next-line: max-line-length
      body: 'repudiandae veniam quaerat sunt sed\nalias aut fugiat sit autem sed est\nvoluptatem omnis possimus esse voluptatibus quis\nest aut tenetur dolor neque'
    }
  ];

  constructor() { }

  getBlogs() {
    return this.blogs;
  }

  getBlog(id: number) {
    return this.blogs.find(b => b.id === id);
  }

  updateBlog(blog: any) {
    // there is a bug here
    let existing = this.blogs.find(b => b.id = blog.id);

    // fix
    // let existing = this.blogs.find(b => b.id === b.id);
    existing = blog;
  }

}
