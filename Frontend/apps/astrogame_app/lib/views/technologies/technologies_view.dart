import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/views/technologies/technologies_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

import 'technology_card_placeholder_view.dart';
import 'technology_card_view.dart';

abstract class TechnologiesView<T extends TechnologiesViewModel>
    extends StatelessWidget {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<T>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(left: 32, right: 32, top: 32),
              child: (model.isBusy) ? SizedBox.shrink() : tabWidget(model),
            ),
            Divider(color: Colors.white),
            Expanded(
              child: Padding(
                  padding: const EdgeInsets.only(left: 0, right: 0),
                  child: (model.isBusy)
                      ? PageView(
                          physics: new NeverScrollableScrollPhysics(),
                          controller: null,
                          children: [
                            _placeholderView(3),
                          ],
                        )
                      : pageView(model)),
            ),
          ],
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget pageView(TechnologiesViewModel model);

  Widget tabWidget(TechnologiesViewModel model);

  Widget _placeholderView(int count) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 32),
      child: ListView.builder(
        itemCount: count,
        itemBuilder: (context, index) => TechnologyCardPlaceholderView(),
      ),
    );
  }

  Widget listView(List<Technology> technologies) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 32),
      child: ListView.builder(
        itemCount: technologies.length,
        itemBuilder: (context, index) =>
            TechnologyCardView(technologies[index]),
      ),
    );
  }
}
