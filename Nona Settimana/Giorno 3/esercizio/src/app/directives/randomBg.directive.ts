import { Directive,ElementRef,OnInit } from '@angular/core';

@Directive({
  selector: '[appRandomBg]'
})
export class RandomBgDirective implements OnInit{

  constructor(private el: ElementRef) {}

  ngOnInit(): void {
    const randomColor = this.getRandomColor();
    this.el.nativeElement.style.backgroundColor = randomColor;
  }
    // ogni tag ha un colore random
  getRandomColor(): string {
    const alfanumeri = '0123456789ABCDEF';
    let colore = '#';
    for (let i = 0; i < 6; i++) {
      colore += alfanumeri[Math.floor(Math.random() * 16)];
    }
    return colore;
  }
}
