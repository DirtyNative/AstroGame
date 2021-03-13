import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class VerticalLinePainter extends CustomPainter {
  @override
  void paint(Canvas canvas, Size size) {
    /*Path path = new Path();
    Paint paint = new Paint()..strokeWidth = 5;

    path.moveTo(size.width / 2, 0);
    path.lineTo(size.width / 2, size.height);

    paint.color = Colors.white;
    canvas.drawPath(path, paint);*/

    var p1 = Offset(size.width / 2, 0);
    var p2 = Offset(size.width / 2, size.height);

    final paint = Paint()
      ..color = Colors.white
      ..strokeWidth = 2;

    canvas.drawLine(p1, p2, paint);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) {
    return false;
  }
}
