import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class Resource {
  @JsonKey()
  Guid id;

  @JsonKey()
  String name;

  @JsonKey()
  int naturalOccurrenceWeight;

  @JsonKey()
  List<StellarObjectResource> stellarObjectResources;

  Resource(
    this.id,
    this.name,
    this.naturalOccurrenceWeight,
    this.stellarObjectResources,
  );
}
