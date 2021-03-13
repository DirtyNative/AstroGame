import 'package:flutter/material.dart';

class DynamicSystemPainter extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<DynamicSystemPainter> {
  Size canvasSize;

  @override
  Widget build(BuildContext context) {
    // Set inital size, maybe move this to initState function
    if (canvasSize == null) {
      // Decide what makes sense in your use-case as inital size
      canvasSize = MediaQuery.of(context).size;
    }

    return CustomPaint(
      size: canvasSize,
      painter: SystemPainter(false, (size) {
        setState(() {
          canvasSize = size;
        });
      }),
    );
  }
}

typedef OnResize = void Function(Size size);

class SystemPainter extends CustomPainter {
  bool _isVertical;
  final OnResize onResize;

  SystemPainter(this._isVertical, this.onResize);

  @override
  void paint(Canvas canvas, Size size) {
    Path path = new Path();
    Paint paint = new Paint();

    path.moveTo(size.width, size.height * 0.25);
    path.quadraticBezierTo(
        size.width / 2, size.height / 2, size.width, size.height * 0.75);

    paint.color = Colors.orange;
    canvas.drawPath(path, paint);

    onResize(size);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) {
    return false;
  }
}
