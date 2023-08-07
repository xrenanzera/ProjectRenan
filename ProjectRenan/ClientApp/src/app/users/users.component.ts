import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  user: any = {};
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.userService.getUsers().subscribe({
      next: (response: any[]) => {
        this.users = response;
      },
      error: (error) => {
        console.log(error);
        alert('erro interno do sistema');
      },
    });
  }
}
