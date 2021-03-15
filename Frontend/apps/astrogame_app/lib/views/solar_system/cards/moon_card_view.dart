import 'package:astrogame_app/models/stellar/stellar_objects/moon.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:stacked/stacked.dart';

import 'moon_card_viewmodel.dart';

class MoonCardView extends StatelessWidget {
  final Moon _moon;

  MoonCardView(this._moon);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<MoonCardViewModel>.reactive(
      builder: (context, model, _) => Container(
        width: 300,
        height: 70,
        child: Row(
          children: [
            SvgPicture.asset(
              'assets/images/moon.svg',
              color: Colors.white,
              semanticsLabel: 'A red up arrow',
              height: 50,
            ),
            /*
            ImageIcon(
              AssetImage('assets/images/moon.png'),
              size: 50,
            ), */
            SizedBox(width: 16),
            Text('${model.moon.name}'),
            SizedBox(width: 16),
            Text(model.moon.coordinates.toString())
          ],
        ),
      ),
      viewModelBuilder: () => MoonCardViewModel(_moon),
    );
  }
}
