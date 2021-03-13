import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class HorizontalLinePainter extends CustomPainter {
  @override
  void paint(Canvas canvas, Size size) {
    var p1 = Offset(0, size.height / 2);
    var p2 = Offset(size.width, size.height / 2);

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
