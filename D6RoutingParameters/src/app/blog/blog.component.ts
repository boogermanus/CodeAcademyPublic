import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BlogService } from '../blog.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BlogEditComponent } from '../blog-edit/blog-edit.component';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit, OnDestroy {

  static readonly ID = 'id';
  blog: any;
  id: number;
  isEditing = false;
  subscription: Subscription;


  constructor(
    private activatedRoute: ActivatedRoute,
    private blogService: BlogService,
    private modalService: NgbModal
  ) {

  }

  ngOnInit(): void {
    // easy way
    const id = +this.activatedRoute.snapshot.params[BlogComponent.ID];
    this.blog = this.blogService.getBlog(id);

    // hard way
    // this.subscription = this.activatedRoute.params.subscribe(params => this.reload(params));
  }

  ngOnDestroy(): void {
    // hard way part duex
    // this.subscription.unsubscribe();
  }

  reload(params: any): void {
      this.blog = this.blogService.getBlog(+params.id);
  }

  async edit(): Promise<void> {
    const modal = this.modalService.open(BlogEditComponent);
    modal.componentInstance.modalInstance = modal;
    modal.componentInstance.blog = this.blog;

    const result = await modal.result;

    this.blog.body = result;
    this.blogService.updateBlog(this.blog);

  }

}
