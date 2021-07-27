import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/resource_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class Resource {
  @JsonKey()
  late Guid id;

  @JsonKey()
  late String name;

  @JsonKey()
  late int naturalOccurrenceWeight;

  @JsonKey()
  List<StellarObjectResource>? stellarObjectResources = [];

  Resource();

  factory Resource.fromJson(Map<String, dynamic> json) =>
      ResourceConverter().fromJson(json);
}
