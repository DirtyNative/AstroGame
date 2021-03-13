import 'dart:ui';

import 'package:flutter/material.dart';

class GlassContainer extends StatelessWidget {
  final Widget child;
  final double width;

  final double sigmaX;
  final double sigmaY;

  final Color shadowColor;
  final double shadowOpacity;
  final double shadowBlurRadius;
  final double shadowSpreadRadius;

  final Color backgroundColor;
  final double backgroundOpacity;

  final BorderRadius borderRadius;
  final double borderWidth;
  final Color borderColor;
  final double borderOpacity;

  final EdgeInsets padding;

  GlassContainer({
    @required this.child,
    this.width = double.infinity,
    this.sigmaX = 16,
    this.sigmaY = 16,
    this.shadowColor = Colors.black,
    this.shadowOpacity = 0.2,
    this.shadowBlurRadius = 16,
    this.shadowSpreadRadius = 8,
    this.backgroundColor = Colors.white,
    this.backgroundOpacity = 0.1,
    this.borderRadius,
    this.borderWidth = 1,
    this.borderColor = Colors.white,
    this.borderOpacity = 0.1,
    this.padding,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(boxShadow: [
        BoxShadow(
          blurRadius: shadowBlurRadius,
          spreadRadius: shadowSpreadRadius,
          color: shadowColor.withOpacity(shadowOpacity),
        )
      ]),
      //width: width,
      child: ClipRRect(
        borderRadius: borderRadius ?? BorderRadius.circular(8),
        child: BackdropFilter(
          filter: ImageFilter.blur(
            sigmaX: sigmaX,
            sigmaY: sigmaY,
          ),
          child: Container(
            padding: padding ?? EdgeInsets.all(16),
            decoration: BoxDecoration(
              color: backgroundColor.withOpacity(backgroundOpacity),
              borderRadius: borderRadius ?? BorderRadius.circular(16),
              border: Border.all(
                width: borderWidth,
                color: borderColor.withOpacity(borderOpacity),
              ),
            ),
            child: child,
          ),
        ),
      ),
    );
  }
}
