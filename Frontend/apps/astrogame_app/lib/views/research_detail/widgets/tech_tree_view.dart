import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/views/research_detail/widgets/tech_tree_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:graphview/GraphView.dart';
import 'package:stacked/stacked.dart';

class TechTreeView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<TechTreeViewModel>.reactive(
      builder: (context, model, snapshot) => InteractiveViewer(
        child: GraphView(
          algorithm: BuchheimWalkerAlgorithm(
            model.builder,
            TreeEdgeRenderer(model.builder),
          ),
          graph: model.graph,
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
